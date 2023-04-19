import { Box } from '../components/Box'
import { Footer } from '../components/Footer'
import { Topbar } from '../components/Topbar'


export function Login(){
    return(
        <div>
            <Topbar/>
            <div className="bg-black">

                <div className="flex flex-row h-screen lg:flex-row items-center justify-center shadow-xl bg-[#FFDEF6]">
                    <div className="flex flex-col justify-init items-center bg-white rounded-lg lg:h-[65%] lg:w-[35%] lg:mt-[-10%]">

                        <div className="italic font-extrabold text-3xl text-[#6b0023] lg:mt-[10%]">
                            <span>Não se Cale !</span>
                        </div>

                        <div className="text-ml justify-start items-center">
                            <div>
                                <textarea placeholder="....Email ou Telefone" className="lg:mt-[20%] lg:w-[210%] lg:ml-[-60%] border-2 rounded-lg"/> 
                            </div>

                            <div>
                                <textarea placeholder="....Senha" className="lg:mt-[5%] lg:w-[210%] lg:ml-[-60%] border-2 rounded-lg"/> 
                            </div>

                            <div className="mt-[15%] text-center border-solid border-2 rounded-lg p-2 bg-[#a6024f] text-white text-2xl lg:ml-[-20%]">
                                <span>Entrar</span>
                            </div>

                            <div className="text-md text-black lg:my-[5%]">
                                <span>Esqueceu a Conta ?</span>
                            </div>

                            <div className="mt-[5%] text-center border-solid border-2 rounded-lg p-2 bg-[#a6024f] text-white text-2xl lg:ml-[-20%]">
                                <span>Criar uma Conta</span>
                            </div>

                        </div>

                    </div>

                </div>

            </div>
            <Footer/>
        </div>
    )
}