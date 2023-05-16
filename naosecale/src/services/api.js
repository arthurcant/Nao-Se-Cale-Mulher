import axios from "axios";
import { useNavigate } from "react-router-dom";

const api = axios.create({
    baseURL: 'https://localhost:7126'
})
//

async function FirstLogin() {
    const data = {
        email: "arthurbig12@gmail.com",
        password: "admin213!"
    }

    const history = useNavigate();

    try {

        const response = await api.post('/api/Autenticacao/v1/signin', data);

        localStorage.setItem('email', data.email);
        localStorage.setItem('accessToken', response.data.accessToken);
        localStorage.setItem('refreshToken', response.data.refreshToken);
        history("/")

    }catch(error){
        if (error.response.status === 401) {

            console.log(error.response.data);
            console.log(error.response.status);
            console.log(error.response.headers);
            console.log("Error response");
        } else if (error.request) {
            
            console.log(error.request); 
            console.log("Error response");
        } else {

            console.log('Error', error.message);
        }

        console.log(error.config);
        alert("Erro login invalid!")
    }
}



export default { api, FirstLogin };