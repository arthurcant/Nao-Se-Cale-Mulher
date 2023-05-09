import axios from "axios";
const api = axios.create({
    baseURL: 'https://naosecalemulher.azurewebsites.net'
})

export default api;