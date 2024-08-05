
import axios from "axios"

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