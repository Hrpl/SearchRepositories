import axios from 'axios';

// ѕроверим в самом начале, есть ли токен в хранилище
const JWTToken = localStorage.getItem('jwt');

// —оздать инстанс axios
const api = axios.create({
    baseURL: `http://localhost:5080/api/`
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

api.interceptors.request.use(config => {
    // ≈сли пользователь делает запрос и у него нет заголовка с токеном, то...
    if (!config.defaults.headers['Authorization']) {
        // “ут пишем редирект если не авторизован
    }

    return config;
}, error => {
    return Promise.reject(error);
});

export default api;
