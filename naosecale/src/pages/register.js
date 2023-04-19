import { Box } from '../components/Box'
import { Footer } from '../components/Footer'
import { Topbar } from '../components/Topbar'


export function Register(){
    return(
        <div>
            <Topbar/>
            <div className="bg-black">

                <div className="flex flex-row h-screen lg:flex-row items-center justify-center shadow-xl bg-[#FFDEF6]">
                    <div className="flex flex-col justify-init items-center bg-white rounded-lg lg:h-[70%] lg:w-[35%] lg:my-[10%]">

                        <div className="italic font-extrabold text-3xl text-[#6b0023] ">
                            <span>Não se Cale !</span>
                        </div>

                        <div className=" flex flex-col text-ml justify-start items-center lg:mt-[10%]">
                            <div className="flex flex-row">
                                <textarea placeholder="Nome" className="lg:w-[150%] border-2 rounded-lg text-center"/> 

                                <textarea placeholder="Sobrenome" className="lg:w-[150%] border-2 rounded-lg text-center"/> 
                        </div>

                            <div className="lg:mt-[5%] justify-start items-start">
                                <textarea placeholder="Celular ou Email" className="lg:w-[200%] border-2 rounded-lg lg:ml-[-50%] text-center"/> 
                            </div>

                            <div className="lg:mt-[2%] justify-start items-start">
                                <textarea placeholder="Nova Senha" className="lg:w-[200%] border-2 rounded-lg lg:ml-[-50%] text-center"/> 
                            </div>
                            
                            <span>Data de nascimento</span>

                            <div className="flex flex-row lg:h-[100%]">
                                <textarea placeholder="17" className="lg:w-[150%] border-2 rounded-lg text-center"/> 

                                <textarea placeholder="Abr" className="lg:w-[150%] border-2 rounded-lg text-center"/> 

                                <textarea placeholder="2023" className="lg:w-[150%] border-2 rounded-lg text-center"/> 
                            </div>

                            <span>Gênero</span>

                            <div className="flex flex-row lg:h-[100%]">
                                <textarea placeholder="17" className="lg:w-[150%] border-2 rounded-lg text-center"/> 

                                <textarea placeholder="Abr" className="lg:w-[150%] border-2 rounded-lg text-center"/> 

                                <textarea placeholder="2023" className="lg:w-[150%] border-2 rounded-lg text-center"/> 
                            </div>

                        </div>

                    </div>

                </div>

            </div>
            <Footer/>
        </div>
    )
}