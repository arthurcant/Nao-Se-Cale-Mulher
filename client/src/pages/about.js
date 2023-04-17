import { Box } from '../components/Box'
import { Topbar } from '../components/Topbar'
import { Footer } from '../components/Footer'

export function About(){
    return(
        <div>
            <Topbar/>
            <div className="flex flex-col lg:flex-row items-center justify-between shadow-xl bg-[#FFDEF6]">
    
                <div className="border-solid shadow-xl lg:m-96 lg:my-14 bg-white rounded-lg">

                    <div className="flex flex-col lg:flex-row lg:m-20 lg:ml-56 lg:mt-15 text-4xl">
                        <span>Sobre</span>
                        <input type="text" className="hidden lg:flex shadow-lg border-2 hover:border-pink-500 ml-20 rounded-full text-black transition-colors margin lg:ml-20 lg:w-60 lg:ml-10 text-2xl"/>
                    </div>

                    <div className="border-solid border-2 p-40 lg:m-20 shadow-xl  "></div>
        
                    <div className="lg:m-20 lg:mt-30">
                    <a>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</a>
                        </div>
                </div>
            </div>

            <Footer/>
        </div>
    )
}