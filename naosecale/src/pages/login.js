import { Link } from "react-router-dom";
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import api from "../services/api";
import { Box } from '../components/Box'
import { Footer } from '../components/Footer'
import { Topbar } from '../components/Topbar'


    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const history = useNavigate();

    async function login(e) {
        e.preventDefault();

        const data = {
            email: "arthurbig12@gmail.com",
            password: "admin213!"
        }

        try {

            const response = await api.post('https://localhost:7126/swagger/v1/api/Autenticacao/v1/signin', data).catch((error) => {
                console.log(error)
            })

            localStorage.setItem('email', data.email);
            localStorage.setItem('accessToken', response.data.accessToken);
            localStorage.setItem('refreshToken', response.data.refreshToken);
            history("/")

        }catch(error){
            if (error.response.status === 401) {

                alert("Acesso não autorizado.");
            } else if (error.request) {
                
                console.log(error.request); 
                console.log("Error do servidor");
            } else {

                console.log('Error', error.message);
            }

            alert("Erro login invalid!")
            console.log(error.config);
        }
    }

    return (
        <div>
            <div className="bg-black">

                <div className="flex flex-row h-screen w-ful lg:flex-row items-center justify-center shadow-xl bg-[#FFDEF6]">
                    <div className="flex flex-col justify-center items-center bg-white rounded-lg lg:h-[65%] lg:w-[30%] w-[79.9%] h-[80%]">

                        <div className="italic font-extrabold text-3xl text-[#6b0023] mb-[20%]">
                            <span>Não se Cale !</span>
                        </div>

                        <div className="text-ml justify-center items-center gap-2">

                            <div className="flex flex-col lg:flex-col w-full gap-5">
                                <input type='text' placeholder="Email" onChange={((e) => setEmail(e.target.value))} className="lg:w-full border-2 rounded-lg p-2" />

                                <input type='text' placeholder="Senha" onChange={((e) => setPassword(e.target.value))} className="lg:w-full border-2 rounded-lg p-2" />
                            </div>

                            {/* <Link to="/"> */}
                            <div onClick={login} className="cursor-pointer mt-[15%] text-center border-solid border-2 rounded-lg p-2 bg-[#a6024f] text-white text-2xl">
                                <span>Entrar</span>
                            </div>
                            {/* </Link> */}

                            <div className="text-md text-black lg:my-[5%] text-center">
                                <button>Esqueceu a Conta ?</button>
                            </div>


                            <Link to="/register">
                                <div className="text-center border-solid border-2 rounded-lg p-2 bg-[#a6024f] text-white text-2xl">
                                    <span>Criar uma Conta</span>
                                </div>
                            </Link>

                        </div>

                    </div>

                </div>

            </div>
            <Footer />
        </div>
    )
}