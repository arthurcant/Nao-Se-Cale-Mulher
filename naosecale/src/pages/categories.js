import { Box } from '../components/Box'
import { Topbar } from '../components/Topbar'
import { SearchBar } from '../components/SearchBar'
import { Footer } from '../components/Footer'
import { BoxCategory } from '../components/BoxCategory'
import { FaArrowRight } from 'react-icons/fa';

export function Categories(){
    return(
            <div>
                <Topbar/>
                <div className="flex flex-col w-full h-screen lg:flex-row items-center justify-center shadow-xl bg-[#FFDEF6]">
        
                        <div className="flex items-start justify-center h-[85%] lg:w-[50%] shadow-xl bg-white rounded-lg">
                            <div className="flex flex-col w-full items-center justify-center py-10">
                                <div className="lg:my-6 justify-center text-center text-4xl mt-[-5%]">
                                    <span className="font-semibold">Categorias</span>
                                </div>
                                
                                <SearchBar/>

                                <div className="flex flex-col w-[80%] justify-center items-center gap-3 mt-[5%]">
                                    <BoxCategory />
                                    <BoxCategory />
                                    <BoxCategory />
                                    <BoxCategory />
                                    <BoxCategory />

                                    <div className="items-center gap-3 flex flex-row">
                                        <span>1 2 3 4...</span>
                                        <FaArrowRight className="text-lg"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                </div>

            <Footer/>
            </div>

    )
}