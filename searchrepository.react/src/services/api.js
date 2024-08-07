import axios from 'axios';

// ѕроверим в самом начале, есть ли токен в хранилище
const JWTToken = localStorage.getItem('jwt');

// —оздать инстанс axios
const api = axios.create({
    baseURL: `http://87.242.85.8:5080/api/`
});

export function apiSetHeader(name, value) {
    if (value) {
        api.defaults.headers[name] = value;
    }
};

// ≈сли токен есть, то добавим заголовок к запросам
if (JWTToken) {
    apiSetHeader('Authorization', `Bearer ${JWTToken}`);
}


export default api;
