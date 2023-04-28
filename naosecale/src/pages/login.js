import { Box } from '../components/Box'
import { Footer } from '../components/Footer'
import { Topbar } from '../components/Topbar'


export function Login(){
    return(
        <div>
            <Topbar/>
            <div className="bg-black">

                <div className="flex flex-row h-screen lg:flex-row items-center justify-center shadow-xl bg-[#FFDEF6]">
                    <div className="flex flex-col justify-center items-center bg-white rounded-lg lg:h-[65%] lg:w-[50%] w-full">

                        <div className="italic font-extrabold text-3xl text-[#6b0023] lg:my-[3%] mt-[5%]">
                            <span>Não se Cale !</span>
                        </div>

                        <div className="text-ml justify-center items-center gap-2">
                            <div>
                                <textarea placeholder="....Email ou Telefone" className="w-full border-2 rounded-lg p-2"/> 
                            </div>

                            <div>
                                <textarea placeholder="....Senha" className="w-full border-2 rounded-lg p-2"/> 
                            </div>

                            <div className="mt-[15%] text-center border-solid border-2 rounded-lg p-2 bg-[#a6024f] text-white text-2xl">
                                <span>Entrar</span>
                            </div>

                            <div className="text-md text-black lg:my-[5%]">
                                <span>Esqueceu a Conta ?</span>
                            </div>

                            <div className="text-center border-solid border-2 rounded-lg p-2 bg-[#a6024f] text-white text-2xl">
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