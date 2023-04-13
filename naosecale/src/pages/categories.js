import { Box } from '../components/Box'
import { Topbar } from '../components/Topbar'
import { Footer } from '../components/Footer'
import { FaHome, FaPhoneAlt, FaFlag, FaInfoCircle, FaExclamationTriangle, FaSearch, FaArrowRight } from 'react-icons/fa';

export function Categories(){
    return(
        <>
            <div>
                <Topbar/>
                <div className="flex flex-col lg:flex-row items-center justify-between shadow-xl bg-[#FFDEF6]">
        
                        <div className="border-solid shadow-xl lg:m-96 lg:my-14 bg-white rounded-lg px-[248px]">

                            <div className="flex lg:flex-col">

                                <div className=" hidden bg-white items-center lg:flex shadow-lg border-2 hover:border-pink-500 rounded-full text-black p-2 transition-colors lg:w-64 lg:my-5">
                                    <FaSearch className="text-lg"/>
                                
                                <input type="text" className="hover:border-pink-500 focus:outline-none text-black p-2 transition-colors ml-0"/></div>

                                    <div className="lg:my-6 justify-center text-center text-4xl">
                                        <span># Categorias</span>
                                    </div>

                            </div>

                            <div className="ml-[0%]">
                                <div className="flex flex-col text-2xl border-2 border-[#6b0023] p-full">
                                    <span>Violência contra a Mulher</span>
                                    <a className="text-sm">#Diga não</a>
                                </div>
                                <div className="flex flex-col text-2xl border-2 border-[#6b0023] w-full h-full">
                                    <span>Violência contra a Mulher</span>
                                    <a className="text-sm">#Diga não</a>
                                </div>
                                <div className="flex flex-col text-2xl border-2 border-[#6b0023] w-full h-full">
                                    <span>Violência contra a Mulher</span>
                                    <a className="text-sm">#Diga não</a>
                                </div>
                                <div className="flex flex-col text-2xl border-2 border-[#6b0023] w-full h-full">
                                    <span>Violência contra a Mulher</span>
                                    <a className="text-sm">#Diga não</a>
                                </div>
                                <div className="flex flex-col text-2xl border-2 border-[#6b0023] w-full h-full">
                                    <span>Violência contra a Mulher</span>
                                    <a className="text-sm">#Diga não</a>
                                </div>
                                <div className="flex flex-col text-2xl border-2 border-[#6b0023] w-full h-full">
                                    <span>Violência contra a Mulher</span>
                                    <a className="text-sm">#Diga não</a>
                                </div>
                                <div className="text-center items-center gap-3 flex flex-row my-6 ml-[40%]">
                                    <span>1 2 3 4...</span>
                                    <FaArrowRight className="text-lg"/>
                                </div>
                            </div>
                
                            
                        </div>
                </div>

            <Footer/>
            </div>
        </>

    )
}