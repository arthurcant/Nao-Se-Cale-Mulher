import { Box } from '../components/Box'
import { Footer } from '../components/Footer'
import { Topbar } from '../components/Topbar'
import { Pagination } from '../components/Pagination'
import { Posts } from '../components/Posts'
import { Tags } from '../components/Tags'
import api  from '../services/api'

import { FaHome, FaPhoneAlt, FaFlag, FaInfoCircle, FaExclamationTriangle, FaSearch, FaArrowRight, FaArrowLeft } from 'react-icons/fa';

import React, { useState, useEffect} from 'react'

export function Index() {

    const [posters, setPosters] = useState([]);
    const [page, setPage] = useState(1);

    const email = localStorage.getItem('email')
    const accessToken = localStorage.getItem('accessToken')

    const authorization = {
        headers: {
            Authorization: `Bearer ${accessToken}`
        }
    }

    useEffect(() => {
        fetchMorePosters()
    }, [accessToken])

    async function fetchMorePosters() {
        const response = await api.get(`/api/posteres/v1/asc/4/2`, authorization)
        console.log(response)
        setPosters([...response.data.list])
        setPage(page + 1);
    }

    return(
        <div className='w-full'>
            <Topbar/>

            <div className="bg-[#FFDEF6]">
    
                <div className="flex flex-col lg:flex-row items-start justify-between shadow-xl bg-[#FFDEF6]">
                    <div className="ml-7 border-solid border-2 rounded-lg shadow-xl lg:p-20 p-10 pt-10 lg:mt-16 bg-white">
                  {posters.map((poster, index) => (
                    <Posts 
                    id={poster.id} 
                    titulo={poster.titulo} 
                    dataDaPublicacao={Intl.DateTimeFormat('pt-BR').format(new Date(poster.dataDaPublicacao))} 
                    descricao={poster.descricao}/>
                  ))}  
                    <div className="ml-[40%]"><Pagination/></div>

                    </div>

                    <div className="p-10 bg-[#FFDEF6]"></div>
    
                    <div className="lg:mt-16 bg-white border-solid border-2 shadow-xl rounded-lg lg:p-14 p-5 pt-10 mr-10">
                        <div className="mb-10 text-center border-solid border-2 rounded-lg p-2 bg-[#a6024f] text-white text-3xl">
                            <span>Canais de Apoio</span>
                        </div>

                        <div>
                            <a>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</a>
                        </div>
                    </div>

                </div>

            </div>

            <Footer/>
        </div>
    )
}
