import { Box } from '../components/Box'
import { Footer } from '../components/Footer'
import { Topbar } from '../components/Topbar'
import { FaTrashAlt } from 'react-icons/fa';
import { ImParagraphLeft } from 'react-icons/im';
import { AiOutlineGif, AiOutlineCamera } from 'react-icons/ai' ;

export function Write(){
    return(
        <div>
            <Topbar/>

                <div className="bg-black">
                    <div className="flex flex-col h-screen lg:flex-row items-center justify-center shadow-xl bg-[#FFDEF6]">

                        <div className="flex justify-center items-start bg-white rounded-lg lg:h-[85%] lg:w-[48%] h-[85%] w-[85%]">
                            <div className="flex flex-col w-full h-full justify-center items-center"> 
                                <div className="text-3xl text-center">
                                    <span className="font-semibold">Administração</span>
                                </div>

                                <div className="lg:w-[70%] w-[85%] h-[35%] text-xl lg:mt-10 mt-[15%]">
                                    <textarea placeholder="Escrever..." className="w-full h-full p-3 text-black border-black hover:border-pink-500 focus:outline-none border-4 shadow-xl transition-colors rounded-3xl resize-none bg-[#efe3ec]"/>                    
                                </div>

                                
                                <div className="justify-start items-start flex flex-row items-center gap-5 h-[15%]">
                                        <div className="gap-40 lg:ml-[-70%]">
                                            <FaTrashAlt className="text-2xl hover:text-[#6b0023]" />
                                        </div>  

                                        <div className="text-pink-500 hover:text-[#6b0023] lg:ml-[150%]">
                                            <span>Rascunho</span>
                                        </div>
                                   
                                    <div className="text-white border-2 bg-[#6b0023] hover:border-pink-500 p-2 rounded-full">
                                        <span>Enviar</span>
                                    </div>

                                </div>

                                <div className="lg:justify-end items-end flex flex-row w-[60%] h-[15%] gap-3 justify-center">
                                    <ImParagraphLeft className="text-3xl hover:text-[#6b0023] hover:box-content"/>
                                    <AiOutlineGif className="text-3xl border-2 border-black hover:text-[#6b0023]  "/>
                                    <AiOutlineCamera className="text-3xl hover:text-[#6b0023]" />
                                </div>

                            </div>
                        </div>

                    </div>

                </div>
            <Footer/>
        </div>
    )

}

