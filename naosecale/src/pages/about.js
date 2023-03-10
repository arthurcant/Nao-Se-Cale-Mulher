import { Box } from '../components/Box'
import { Topbar } from '../components/Topbar'

export function About(){
    return(
        <div>
            <Topbar/>
    
            <div className="w-full h-full justify-center items-center align-middle bg-[#A1607F] p-8">
                <div className="flex flex-col w-full lg:w-[45%] pt-0 lg:pt20 pl-0 items-center ml-20">
                    <a className="italic font-extrabold text-2xl pb-14">Lorem ipsum</a>
                    <span>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum</span>
                </div>
            </div>
    
        </div>
    )
}