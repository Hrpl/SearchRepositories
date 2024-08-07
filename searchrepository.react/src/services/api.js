import axios from 'axios';

// �������� � ����� ������, ���� �� ����� � ���������
const JWTToken = localStorage.getItem('jwt');

// ������� ������� axios
const api = axios.create({
    baseURL: `http://87.242.85.8:5080/api/`
});

export function apiSetHeader(name, value) {
    if (value) {
        api.defaults.headers[name] = value;
    }
};

// ���� ����� ����, �� ������� ��������� � ��������
if (JWTToken) {
    apiSetHeader('Authorization', `Bearer ${JWTToken}`);
}


export default api;
