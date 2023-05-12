import { Box } from '../components/Box'
import { Topbar } from '../components/Topbar'
import { Footer } from '../components/Footer'
import { FaHome, FaPhoneAlt, FaFlag, FaInfoCircle, FaExclamationTriangle, FaSearch,FaArrowRight } from 'react-icons/fa';
import { Pagination } from '../components/Pagination'

export function Contact() {
    return(
        <>
            <div>
                <Topbar/>
                <div className="flex flex-col w-screen lg:h-screen lg:flex-row items-center justify-center shadow-xl bg-[#FFDEF6]">
        
                    <div className="flex flex-col items-start justify-center lg:mt-[0%] lg:w-[50%] h-[85%] w-[90%] h-shadow-xl bg-white rounded-lg mt-[15%] shadow-xl">

                        <div className="flex lg:flex-row lg:m-[10%] lg:ml-[25%] lg:mt-15 flex-col items-center justify-center text-4xl ml-[30%] mb-[5%] lg:mb-[5%]">
                            <span>Contato</span>
                            <input type="text" className="hidden lg:grid lg:flex-row shadow-lg border-2 hover:border-pink-500 ml-20 rounded-full text-black transition-colors margin lg:ml-20 lg:w-60 lg:ml-10 lg:text-2xl"/>
                        </div>
            
                        <div className="lg:w-[80%] flex lg:flex-col lg:m-20 lg:mt-[0%] 
                        flex-col text-center justify-center ">
                            <a href="/contacts">Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999</a>
                            <a href="/contacts">Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999</a>
                            <a href="/contacts">Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999</a>
                            <a href="/contacts">Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999</a>
                            <a href="/contacts">Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999</a>
                            <a href="/contacts">Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999</a>
                            <a href="/contacts">Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999</a>
                            <a href="/contacts">Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999</a>
                            <a href="/contacts">Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999</a>
                            <a href="/contacts">Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999</a>
                            <a href="/contacts">Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999</a>
                            <a href="/contacts">Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999</a>
                            <a href="/contacts">Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999</a>
                            <a href="/contacts">Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999</a>
                            <a href="/contacts">Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999</a>
                            <a href="/contacts">Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999</a>
                            <a href="/contacts">Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999</a>
                            <a href="/contacts">Lorem Ipsum Av.Lorem Ipsum........................(99)99999-9999</a>

                            <div className="lg:mt-[5%]"><Pagination/></div>
                        </div>

                    </div>
                </div>
            <Footer/>
            </div>
        </>
    ) 
}