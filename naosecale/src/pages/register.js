import React, {useState} from "react";
import { useNavigate } from "react-router-dom";
import api from "../services/api";
import { Box } from '../components/Box'
import { Footer } from '../components/Footer'
import { Topbar } from '../components/Topbar'


export function Register(){
    
    const [nomeCompleto, setNomeCompleto] = useState("")
    const [email, setEmail] = useState("");
    const [senha, setSenha] = useState("");
    const [apelido, setApelido] = useState("");

    const history = useNavigate();

    async function actionResgister() {

        const data = {
            nomeCompleto: "string",
            email: "string",
            senha: "string",
            apelido: "string"
        }
    
        try{
            const response = await api.post('/api/Autenticacao/v1/registe', data)
            history("/login")

        }catch(error) {
    
        }
    }

    
    return(
        <div>
            <div className="bg-black">

                <div className="flex flex-row h-screen lg:flex-row items-center justify-center shadow-xl bg-[#FFDEF6]">
                    <div className="flex flex-col justify-center items-center bg-white rounded-lg lg:h-[75%] lg:w-[50%] w-full">

                        <div className="italic font-extrabold text-3xl text-[#6b0023] lg:mt-[5%] mt-[5%]">
                            <span>Não se Cale !</span>
                        </div>

                        <div className=" flex flex-col w-[50%] justify-start items-center lg:mt-[1%] mt-[10%] gap-5 py-10">
                            <div className="flex flex-col lg:flex-row w-full gap-5">
                                <input type='text' placeholder="Nome" className="lg:w-[50%] border-2 rounded-lg p-2"/> 

                                <input type='text' placeholder="Sobrenome" className="lg:w-[50%] border-2 rounded-lg p-2"/> 
                            </div>

                            <div className="w-full lg:mt-[5%]">
                                <input type='email' placeholder="Email" className="w-full border-2 rounded-lg p-2"/> 
                            </div>

                            <div className="w-full lg:mt-[2%]">
                                <input type='password' placeholder="Nova Senha" className="w-full border-2 rounded-lg p-2"/> 
                            </div>
                            
                            <div className= "flex flex-col w-full justify-start items-start lg:mt-[2.5%]">
                                <span>Data de nascimento</span>

                                <div className=" lg:h-[100%] ">
                                    <input type="date" placeholder="Paloma" className="w-full border-2 rounded-lg p-2"/> 
                                </div>
                            </div>
                            
                            <div className="flex flex-col w-full lg:h-[100%] mb-[5%]">
                                <span>Gênero</span>
                                <div className="border-2 p-2 w-[80%] border-[#6b0023] rounded-md">
                                    <select>
                                        <option value="masc">Masculino</option>
                                        <option value="fem">Feminino</option>
                                    </select>
                                </div>
                            </div>

                            <div onClick={actionResgister} className="mt-[15%] text-center border-solid border-2 rounded-lg p-2 bg-[#a6024f] text-white text-2xl">
                                <span>Cadastrar</span>
                            </div>

                        </div>

                    </div>


                </div>

            </div>
            <Footer/>
        </div>
    )
}