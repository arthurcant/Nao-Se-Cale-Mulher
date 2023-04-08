import { Link } from "react-router-dom";
import { Hamburguer } from './HamburguerBtn'

export function Topbar(){
    return(
        <div className="flex flex-row w-full items-center justify-between py-7 shadow-xl text-white bg-[#6b0023] px-10">
            <div className="italic font-extrabold items-center text-xl lg:text-2xl">
                <Link to="/"><span className="hidden lg:flex">Não Se Cale !</span></Link>
                <Link to="/"><span className="flex lg:hidden">NSC!</span></Link>
            </div>

            <input type="text" className="hidden lg:flex shadow-lg border-2 hover:border-pink-500 ml-20 rounded-full text-black p-2 transition-colors margin lg:ml-0"/>

            <div className="hidden lg:flex gap-4">
                <div className="underline flex flex-row items-center">
                    <Link to="/"><span>Home</span></Link>
                </div>

                <div className="underline flex flex-row items-center">
                    <Link to="/"><span>Categorias</span></Link>
                </div>

                <div className="underline flex flex-row items-center">
                    <Link to="/sobre"><span>Sobre</span></Link>
                </div>

                <div className="underline flex flex-row items-center">
                    <Link to="/"><span>Contato</span></Link>
                </div>

                <div className="underline flex flex-row items-center">
                    <Link to="/"><span>Ligue 180</span></Link>
                </div>
            </div>

            <div className="flex lg:hidden">
                <Hamburguer/>
            </div>
      </div>
    )
}