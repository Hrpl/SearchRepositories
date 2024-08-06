import axios from "axios"
/*87.242.85.8*/
import api, { apiSetHeader } from './api'

export async function authorize(username, password) {
    try {
        const { data } = await api.get(`user/login/${username}/${password}`);

        localStorage.setItem('jwt', data.access);
        apiSetHeader('Authorization', `Bearer ${data.token}`);
        return data.token;
        
    } catch (error) {
        console.log(error);
        return null;
    }
};

export async function apiGetRepository(subject) {

    const config = {
        method: 'post',
        url: 'http://localhost:5080/api/find',
        data: subject,
        headers: {
            'Content-Type': 'application/json'
        }
    }

    const data = await axios(config)

    return data.data
    
}

export async function apiDeleteRepository(subject) {

    axios.delete(`http://localhost:5080/api/find/${subject}`).then((resp) => {
        if (resp.status == 204) {
            alert("Delete request")
        }
    }).catch((error) => alert("No such request exists"))
}