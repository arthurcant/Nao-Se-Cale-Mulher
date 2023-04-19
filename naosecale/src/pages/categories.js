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
                <div className="flex flex-col h-screen lg:flex-row items-center justify-center shadow-xl bg-[#FFDEF6]">
        
                        <div className="flex items-start justify-center h-[85%] lg:w-[48%] shadow-xl bg-white rounded-lg px-[248px]">
                            <div className="flex flex-col items-center justify-center h-[100%]">
                                <SearchBar/>

                                <div className="lg:my-6 justify-center text-center text-4xl">
                                    <span className="font-semibold">Categorias</span>
                                </div>

                                <div className="flex flex-col justify-center items-center gap-3">
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