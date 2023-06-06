import { Box } from '../components/Box'
import { Footer } from '../components/Footer'
import { Topbar } from '../components/Topbar'
import { Pagination } from '../components/Pagination'
import { Posts } from '../components/Posts'
import { Tags } from '../components/Tags'
import api from '../services/api'
import Cookie from 'js-cookie'
import decode from 'jwt-decode'


import { FaHome, FaPhoneAlt, FaFlag, FaInfoCircle, FaExclamationTriangle, FaSearch, FaArrowRight, FaArrowLeft } from 'react-icons/fa';

import React, { useState, useEffect } from 'react'

export function Index() {
    const [currentPage, setCurrentPage] = useState(0);
    const [totalResults, setTotalResults] = useState(0);
    const [pageSize, setPageSize] = useState(4);
    const [listPosters, setListPosters] = useState([]);
    const [user, setUser] = useState({})
    const token = Cookie.get('Admin-cookie-MyRocket')

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

    useEffect(() => {
        if (token) {
            const token = decode(token)
            setUser(token)
        } 
    }, [token])

    async function fetchMorePosters(numPage = 1) {
        const response = await api.get(`/api/posteres/v1/asc/${pageSize}/${numPage}`, authorization)

        console.log(response)

        setPageSize(response.data.pageSize)
        setTotalResults(response.data.totalResults)
        setCurrentPage(response.data.currentPage)
        setListPosters([...response.data.list])
    }

    function calcNumPage() {
        var td = [];
        let numerosDePaginas = (totalResults % 2 == 0 ? totalResults / pageSize : (totalResults / pageSize) + 1);
        for (let index = 1; index <= numerosDePaginas; ++index) {
            td.push(index)
        }
        return td;
    }

    return (
        <div className='w-full'>
            <Topbar />

            <div className="bg-[#FFDEF6]">

                <div className="flex flex-col lg:flex-row items-start justify-between shadow-xl bg-[#FFDEF6]">
                    <div className="flex flex-col ml-7 border-solid border-2 rounded-lg shadow-xl lg:p-20 p-10 pt-10 lg:mt-16 bg-white gap-10">
                        {listPosters.map((poster) => (
                            <Posts
                                id={poster.id}
                                titulo={poster.titulo}
                                dataDaPublicacao={Intl.DateTimeFormat('pt-BR').format(new Date(poster.dataDaPublicacao))}
                                descricao={poster.descricao}
                                categorias={poster.tags}
                            />
                        ))}

                        <div className='flex items-center gap-5 w-full justify-center'>
                            {calcNumPage().map((element, index) =>
                                <div key={index}>
                                    <button onClick={() => fetchMorePosters(element)}>{element}</button>
                                </div>
                            )}
                        </div>

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

            <Footer />
        </div>
    )
}
