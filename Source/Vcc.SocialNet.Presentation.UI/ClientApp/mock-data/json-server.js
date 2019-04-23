// // currently, routes.json is used for custom routes but if you want more control over routing, 
// // this file can be used to start json-server using node
// const jsonServer = require('json-server');
// const server = jsonServer.create();
// const router = jsonServer.router('./mock-data/db.json');
// const middlewares = jsonServer.defaults();
// const port = process.env.PORT || 62067;
// var db = require('./mock-data/db.json');

// server.use(jsonServer.bodyParser);
// server.use(middlewares);

// // in order to route all requests to /api/v1, we can use either rewriter({ /api/v1/*': '/$1'})
// // * This supports both '/users' and '/api/v1/users'
// server.use(jsonServer.rewriter({
//     '/api/*': '/$1',
//     '/:resource/:category/:categoryval': '/:resource?:category=:categoryval'
// }));
// server.use(router);

// // OR use the following without any rewriter
// // * This supports only '/api/v1/users'
// //server.use('/api/v1', router);

// server.listen(port);

const fs = require('fs');
const bodyParser = require('body-parser');
const jsonServer = require('json-server');
const jwt = require('jsonwebtoken');

const server = jsonServer.create();
const router = jsonServer.router('./mock-data/db.json');
const userdb = JSON.parse(fs.readFileSync('./mock-data/auth.json', 'UTF-8'));
const port = process.env.PORT || 62067;

server.use(jsonServer.defaults());
server.use(bodyParser.urlencoded({extended: true}))
server.use(bodyParser.json())
server.use(jsonServer.rewriter({
    '/api/*': '/$1',
    '/:resource/:category/:categoryval': '/:resource?:category=:categoryval'
}));

const SECRET_KEY = '123456789'; // sames as "AuthTokenSecret" in asp.net core appsettings.json

const expiresIn = '1h';

// Create a token from a payload 
function createToken(payload){
  return jwt.sign(payload, SECRET_KEY, {expiresIn})
}

// Verify the token 
function verifyToken(token){
  return  jwt.verify(token, SECRET_KEY, (err, decode) => decode !== undefined ?  decode : err)
}

// Check if the user exists in database
function isAuthenticated({UserName, Password}){
  return userdb.users.findIndex(user => user.email === UserName && user.password === Password) !== -1
}

server.post('/auth/authenticate', (req, res) => {
  const {UserName, Password} = req.body;
  if (isAuthenticated({UserName, Password} ) === false) {
    const status = 401;
    //const message = 'Incorrect email or password';
    res.status(status).json({Token: null, Success: false});
    return;
  }
  const access_token = createToken({UserName, Password})
  res.status(200).json({Token: access_token, Success: true});
});

server.use(/^(?!\/api\/auth).*$/,  (req, res, next) => {
  if (req.headers.authorization === undefined || req.headers.authorization.split(' ')[0] !== 'Bearer') {
    const status = 401;
    const message = 'Error in authorization format';
    res.status(status).json({status, message});
    return;
  }
  try {
     verifyToken(req.headers.authorization.split(' ')[1]);
     next();
  } catch (err) {
    const status = 401;
    const message = 'Error access_token is revoked';
    res.status(status).json({status, message});
  }
});

server.use(router);

server.listen(port, () => {
  console.log('Run Auth API Server')
});


// server.get('/get/user', (req, res) => {
//   if (req.method === 'GET') {
//     let userId = req.query['userId'];
//     if (userId != null && userId >= 0) {
//       let result = db.users.find(user => {
//         return user.userId == userId;
//       })

//       if (result) {
//         let {id, ...user} = result;
//         res.status(200).jsonp(user);
//       } else {
//         res.status(400).jsonp({
//           error: "Bad userId"
//         });
//       }
//     } else {
//       res.status(400).jsonp({
//         error: "No valid userId"
//       });
//     }
//   }
// });
// server.post('/post/user', (req, res) => {
//   if (req.method === 'POST') {
//     let userId = req.body['userId'];
//     if (userId != null && userId >= 0) {
//       let result = db.users.find(user => {
//         return user.userId == userId;
//       })

//       if (result) {
//         let {id, ...user} = result;
//         res.status(200).jsonp(user);
//       } else {
//         res.status(400).jsonp({
//           error: "Bad userId"
//         });
//       }
//     } else {
//       res.status(400).jsonp({
//         error: "No valid userId"
//       });
//     }
//   }
// });





