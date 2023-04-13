import { Box } from '../components/Box'
import { Topbar } from '../components/Topbar'
import { Footer } from '../components/Footer'
import { FaHome, FaPhoneAlt, FaFlag, FaInfoCircle, FaExclamationTriangle, FaSearch,FaArrowRight } from 'react-icons/fa';

export function Contact() {
    return(
        <>
            <div>
                <Topbar/>
                <div className="flex flex-col lg:flex-row items-center justify-between shadow-xl bg-[#FFDEF6]">
        
                    <div className="border-solid shadow-xl lg:m-96 lg:my-14 bg-white rounded-lg">

                        <div className="flex flex-col lg:flex-row lg:m-20 lg:ml-56 lg:mt-15 text-4xl">
                            <span>Contato</span>
                            <input type="text" className="hidden lg:flex shadow-lg border-2 hover:border-pink-500 ml-20 rounded-full text-black transition-colors margin lg:ml-20 lg:w-60 lg:ml-10 text-2xl"/>
                        </div>
            
                        <div className="lg:m-20 lg:mt-30 lg:mb-5 text-center">
                            <a>
                            Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999<br></br>
                            Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999<br></br>
                            Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999<br></br>
                            Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999<br></br>
                            Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999<br></br>
                            Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999<br></br>
                            Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999<br></br>
                            Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999<br></br>
                            Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999<br></br>
                            Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999<br></br>
                            Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999<br></br>
                            Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999<br></br>
                            Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999<br></br>
                            Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999<br></br>
                            Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999<br></br>
                            Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999<br></br>
                            Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999<br></br>
                            Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999<br></br>
                            Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999<br></br>
                            Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999<br></br>
                            Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999<br></br>
                            </a>
                        </div>
                        <div className="text-center items-center gap-3 flex flex-row ml-[45%] my-6">
                            <span>1 2 3 4...</span>
                            <FaArrowRight className="text-lg"/>
                        </div>
                    </div>
                </div>

            <Footer/>
            </div>
        </>
    ) 
}