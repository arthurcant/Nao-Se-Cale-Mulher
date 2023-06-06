import { Link } from "react-router-dom";
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import api from "../services/api";
import { Box } from '../components/Box'
import { Footer } from '../components/Footer'
import { Topbar } from '../components/Topbar'
import axios from '../data/client'
import Cookie from 'js-cookie'


export function Login() {

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const history = useNavigate();

    function setCookieIdUser(token) {
        Cookie.set('Admin-cookie-MyRocket', token, {
            expires: 7,
        });
    }

    async function login(e) {
        e.preventDefault();

        const data = {
            email,
            password
        }

        try {
            console.log('aaaa')
            const token = await axios.post('/user/create', data).data
            console.log('token')
            console.log(token)
            setCookieIdUser(token)
            history("/")
        } catch (error) {
            console.log(error)
        }
    }

    return (
        <div>
            <div className="bg-black">

                <div className="flex flex-row h-screen lg:flex-row items-center justify-center shadow-xl bg-[#FFDEF6]">
                    <div className="flex flex-col justify-center items-center bg-white rounded-lg lg:h-[65%] lg:w-[50%] w-full">

                        <div className="italic font-extrabold text-3xl text-[#6b0023] lg:my-[3%] mt-[5%]">
                            <span>Não se Cale !</span>
                        </div>

                        <div className="text-ml justify-center items-center gap-2">

                            <div className="flex flex-col lg:flex-row w-full gap-5">
                                <input type='text' placeholder="Email" onChange={((e) => setEmail(e.target.value))} className="lg:w-[50%] border-2 rounded-lg p-2" />

                                <input type='text' placeholder="Senha" onChange={((e) => setPassword(e.target.value))} className="lg:w-[50%] border-2 rounded-lg p-2" />
                            </div>

                            {/* <Link to="/"> */}
                            <div onClick={login} className="mt-[15%] text-center border-solid border-2 rounded-lg p-2 bg-[#a6024f] text-white text-2xl">
                                <span>Entrar</span>
                            </div>
                            {/* </Link> */}

                            {/* <Link to="">
                                <div className="text-md text-black lg:my-[5%] text-center">
                                    <button>Esqueceu a Conta ?</button>
                                </div>
                            </Link> */}

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