import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Box } from '../components/Box'
import { Footer } from '../components/Footer'
import { Topbar } from '../components/Topbar'
import axios from '../data/client'
import Cookie from 'js-cookie'


export function Register() {
    const [nome, setNome] = useState("")
    const [email, setEmail] = useState("");
    const [senha, setSenha] = useState("");
    const [apelido, setApelido] = useState("");
    const [gender, setGender] = useState("")

    const history = useNavigate();

    function setCookieIdUser(token) {
        Cookie.set('Admin-cookie-MyRocket', token, {
            expires: 7,
        });
    }

    async function actionResgister() {

        const data = {
            name: nome,
            email,
            password: senha,
            gender,
            nick: apelido
        }

        console.log(data)

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
                    <div className="flex flex-col justify-center items-center bg-white rounded-lg lg:h-[75%] lg:w-[50%] w-[79.9%] w-full">

                        <div className="italic font-extrabold text-3xl text-[#6b0023] lg:mt-[5%] mt-[5%]">
                            <span>Não se Cale !</span>
                        </div>

                        <div className=" flex flex-col w-[50%] justify-start items-center gap-5 py-10">
                            <div className="flex flex-col lg:flex-row gap-2">
                                <input type='text' onChange={(e) => setNome(e.target.value)} placeholder="Nome" className="lg:w-[50%] border-2 rounded-lg p-2" />

                                <input type='text' onChange={(e) => setApelido(e.target.value)} placeholder="Apelido" className="lg:w-[50%] w-full border-2 rounded-lg p-2" />
                            </div>

                            <div className="lg:w-full w-[105%] lg:mt-[5%]">
                                <input type='email' onChange={(e) => setEmail(e.target.value)} placeholder="Email" className="w-full border-2 rounded-lg p-2" />
                            </div>

                            <div className="w-full lg:mt-[2%] w-[105%]">
                                <input type='password' onChange={(e) => setSenha(e.target.value)} placeholder="Senha" className="w-full border-2 rounded-lg p-2" />
                            </div>

                            <div className="flex flex-col w-full lg:justify-start lg:items-start  items-center">
                                <span>Data de nascimento</span>

                                <div className=" lg:h-[100%] ">
                                    <input type="date" placeholder="Paloma" className="w-full border-2 rounded-lg p-2" />
                                </div>
                            </div>

                            <div className="flex flex-col w-full lg:h-[100%] lg:justify-start lg:items-start items-center">
                                <span>Gênero</span>
                                <div className="border-2 p-2 w-[80%] border-[#6b0023] rounded-md">
                                    <select onChange={(e) => setGender(e.target.value)}>
                                        <option value="masc">Masculino</option>
                                        <option value="fem">Feminino</option>
                                        <option value="fem">Outro</option>
                                    </select>
                                </div>
                            </div>

                            <div onClick={actionResgister} className="text-center border-solid border-2 rounded-lg p-2 bg-[#a6024f] text-white text-2xl">
                                <span>Cadastrar</span>
                            </div>

                        </div>

                    </div>


                </div>

            </div>
            <Footer />
        </div>
    )
}