
/*87.242.85.8*/
import api, { apiSetHeader } from './api'
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
            'Authorization': `Bearer ${localStorage.getItem('jwt')}`
        }
    }

    const data = await api(config)

    return data.data
    
}

export async function apiDeleteRepository(subject) {

    api.delete({
        url: `find/${subject}`,
        headers: {
            'Authorization': `Bearer ${localStorage.getItem('jwt')}`
        }
    }).then((resp) => {
        if (resp.status == 204) {
            alert("Delete request")
        }
    }).catch((error) => alert("No such request exists"))
}