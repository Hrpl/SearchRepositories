//import axios from "../../node_modules/axios"
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