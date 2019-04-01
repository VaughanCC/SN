import { User } from '@app/core/models/user.model';
export const invalidUserEmptyPassword: User = {
    password: '',
    username: 'Choi',
    token: ''
};
export const invalidUserEmptyUsername: User = {
    password: 'password',
    username: '',
    token: ''
};

export const invalidUserEmpty: User = {
    password: '',
    username: '',
    token: ''
};

