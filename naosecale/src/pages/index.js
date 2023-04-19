import { Box } from '../components/Box'
import { Footer } from '../components/Footer'
import { Topbar } from '../components/Topbar'
import { FaHome, FaPhoneAlt, FaFlag, FaInfoCircle, FaExclamationTriangle, FaSearch, FaArrowRight } from 'react-icons/fa';

export function Index(){
    return(
        <div className='w-full'>
            <Topbar/>

            <div className="bg-[#FFDEF6]">
    
                <div className="flex flex-col lg:flex-row items-start justify-between shadow-xl bg-[#FFDEF6]">
                    <div className="ml-7 border-solid border-2 rounded-lg shadow-xl lg:p-20 p-10 pt-10 lg:mt-16 bg-white">

                    <div className="border-solid border-2 p-40 lg:m-5 shadow-xl lg:mt-10"></div>

                        <div className="m-0 ml-5 font-weight: 900">
                            <span>Autor: 19 DE FEVEREIRO DE 2023</span>
                            <div className="font-weight:900 mt-0">
                                <span>Título</span>
                            </div>
                        </div>
                        
                        <div className="m-5">
                            <a>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</a>
                        </div>

                        <div className="border-solid border-2 p-40 lg:m-5 shadow-xl"></div>

                        <div className="mt-0 ml-5  font-weight: 900">
                            <span>Autor: 19 DE FEVEREIRO DE 2023</span>
                            <div className="font-weight:900 mt-0">
                                <span>Título</span>
                            </div>
                        </div>
                        <div className="m-5 ">
                            <a>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</a>
                        </div>

                        <div className="text-center items-center gap-3 flex flex-row ml-[45%]">
                            <span>1 2 3 4...</span>
                            <FaArrowRight className="text-lg"/>
                        </div>

                    </div>

                    <div className="p-10 bg-[#FFDEF6]"></div>
    
                    <div className="lg:mt-16 bg-white border-solid border-2 shadow-xl rounded-lg lg:p-14 p-5 pt-10 mr-10">
                        <div className="mb-10 text-center border-solid border-2 rounded-lg p-2 bg-[#a6024f] text-white text-3xl">
                            <span>Canais de Apoio</span>
                        </div>

                        <div>
                            <a>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</a>
                        </div>
                    </div>

                </div>

            </div>

            <Footer/>
        </div>
    )
}