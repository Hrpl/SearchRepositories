
/*87.242.85.8*/
import api, { apiSetHeader } from './api'
const key = localStorage.getItem('jwt')
export async function authorize(username, password) {
    try {
        const { data } = await api.get(`user/login/${username}/${password}`);

        localStorage.setItem('jwt', data.token);
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
        url: 'find',
        data: subject,
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${key}`
        }
    }

    const data = await api(config)

    return data.data
    
}

export async function apiDeleteRepository(subject) {

    api.delete({
        url: `find/${subject}`,
        headers: {
            'Authorization': `Bearer ${key}`
        }
    }).then((resp) => {
        if (resp.status == 204) {
            alert("Delete request")
        }
    }).catch((error) => alert("No such request exists"))
}