import axios from "axios";

const api = axios.create({
    baseURL: 'https://localhost:7126'
})
//

export default api;