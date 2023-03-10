import { Box } from '../components/Box'
import { Topbar } from '../components/Topbar'

export function Index(){
    return(
        <div className='w-full'>
            <Topbar/>
    
            <div className="w-full bg-[#A1607F] lg:p-14 lg:m-15 p-5 ">
                <div className="flex flex-col w-full text-center lg:pt20 p-0 lg:p-16 items-center m-0 ">
                    <a className="italic font-extrabold text-2xl pb-10">Lorem ipsum</a>
                    <span>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum</span>
                </div>
            </div>
    
            <div className="flex flex-col lg:flex-row items-center justify-between shadow-xl">
                <div className=" bg-[#B39BA6] border-solid border-2 border-black lg:p-20 p-10 pt-10 mt-20">

                <div className="border-solid border-2 border-black p-20 mb-5">
                </div>
                    <div className="mt-5 font-weight: 900">
                    <span>Autor: 19 DE FEVEREIRO DE 2023</span>
                    <div className="font-weight:900 mt-0">
                    <span>Título</span>
                    </div>
                    </div>
                    <div className="mt-5">
                    <a>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum</a>
                    </div>
                </div>

                
    
                <div className="p-10 bg-white">
        
                </div>
    
                <div className=" bg-[#B39BA6] border-solid border-2 border-black lg:p-20 p-5 pt-10 mt-20">
                    <a>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum</a>
                </div>
            </div>
    
        </div>
    )
}