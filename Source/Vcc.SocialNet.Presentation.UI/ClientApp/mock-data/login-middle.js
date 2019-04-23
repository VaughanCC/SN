// module.exports = (req, res, next) => {
//     if (req.method == 'POST' && req.path == '/api/auth/authenticate') {
//       if (req.body.UserName === 'joon.choi@gmail.com' && req.body.password === 'password') {
//         res.status(200).json({})
//       } else { 
//         res.status(400).json({message: 'wrong password'})
//       }
//     } else {
//       next()
//     }
//   }

  // const auth = require('basic-auth');

  // module.exports = (req, res, next) => {
  //   var user = auth(req);
  //   if(req.path !== '/auth/authenticate') {
  //     if (typeof user === 'undefined' || user.name !== 'kamal' || user.pass !== 'secret') {
  //       // We will discuss this line later in this section.
  //       res.header('WWW-Authenticate', 'Basic realm="Access to the API"');
  //       return res.status(401).send({ error: 'Unauthorized', path: req.path });
  //     }  
  //   }
  //   else {
  //     return res.status(200).send({ Token: 'token', Success: true});
  //   }
    
  //   next();
  // };

  
const fs = require('fs');
const bodyParser = require('body-parser');
const jsonServer = require('json-server');
const jwt = require('jsonwebtoken');

const server = jsonServer.create();
const router = jsonServer.router('./mock-data/db.json');
const userdb = JSON.parse(fs.readFileSync('./mock-data/auth.json', 'UTF-8'));

//server.use(bodyParser.urlencoded({extended: true}))
//server.use(bodyParser.json())
server.use(jsonServer.defaults());

const SECRET_KEY = '123456789';

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
function isAuthenticated({email, password}){
  return userdb.users.findIndex(user => user.email === email && user.password === password) !== -1
}


server.post('/auth/authenticate', (req, res) => {
  const {email, password} = req.body
  if (isAuthenticated({email, password}) === false) {
    const status = 401
    const message = 'Incorrect email or password'
    res.status(status).json({status, message})
    return
  }
  const access_token = createToken({email, password})
  res.status(200).json({access_token})
});

server.use(/^(?!\/auth).*$/,  (req, res, next) => {
  if (req.headers.authorization === undefined || req.headers.authorization.split(' ')[0] !== 'Bearer') {
    const status = 401
    const message = 'Error in authorization format'
    res.status(status).json({status, message})
    return
  }
  try {
     verifyToken(req.headers.authorization.split(' ')[1])
     next()
  } catch (err) {
    const status = 401
    const message = 'Error access_token is revoked'
    res.status(status).json({status, message})
  }
});

server.use(router);

server.listen(3000, () => {
  console.log('Run Auth API Server')
});