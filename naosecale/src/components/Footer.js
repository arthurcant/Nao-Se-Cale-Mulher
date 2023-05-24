import { Link } from "react-router-dom";
import { Hamburguer } from './HamburguerBtn'
import { AiOutlineMessage } from 'react-icons/ai'

export function Footer(){
    return(
            <div className="flex lg:justify-evenly mt-5 py-4 shadow-xl text-white bg-[#6b0023] text-lg text-center">

                    <span className="lg:ml-[20%]">@Não Se Cale</span>
                        
                    <div className="">
                        <Link to="/write">
                                <div className="underline flex justify-end items-end shadow-3xl">
                                <AiOutlineMessage className="text-3xl" />
                                </div>
                        </Link>
                    </div>
            </div>
    )


        
    }