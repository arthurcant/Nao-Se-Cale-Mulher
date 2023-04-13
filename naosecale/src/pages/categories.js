import { Box } from '../components/Box'
import { Topbar } from '../components/Topbar'
import { Footer } from '../components/Footer'

export function Categories(){
    return(
        <>
            <div>
                <Topbar/>
                <div className="flex flex-col lg:flex-row items-center justify-between shadow-xl bg-[#FFDEF6]">
        
                    <div className="border-solid shadow-xl lg:m-96 lg:my-14 bg-white rounded-lg lg:max-w-7xl">

                        <div className="flex flex-col lg:flex-column lg:m-20  lg:mt-15 text-4xl lg:ml-[352px]">
                            <input type="text" className="hidden lg:flex shadow-lg border-2 hover:border-pink-500 ml-20 rounded-full text-black transition-colors lg:ml-20 lg:w-50 lg:ml-15 text-2xl justify-center items-center"/>
                            <span>Categorias</span>
                        </div>
            
                        
                    </div>
                </div>

            <Footer/>
            </div>
        </>

    )
}