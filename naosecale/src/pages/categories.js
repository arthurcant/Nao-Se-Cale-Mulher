import { Box } from '../components/Box'
import { Topbar } from '../components/Topbar'
import { SearchBar } from '../components/SearchBar'
import { Footer } from '../components/Footer'
import { BoxCategory } from '../components/BoxCategory'
import { Pagination } from '../components/Pagination'
import api  from '../services/api'
import React, { useState, useEffect} from 'react'

export function Categories(){
    
    const [currentPage, setCurrentPage] = useState(0);
    const [amountPages, setAmountPages] = useState(0);
    const [totalResults, setTotalResults] = useState(0);
    const [pageSize, setPageSize] = useState(4);
    const [listCategorias, setListPosters] = useState([]);
    const [listNum, setListNum] = useState([]);
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
    
    async function fetchMorePosters(numPage = 1) {
        const response = await api.get(`/api/categorias/v1/asc/${pageSize}/${numPage}`, authorization)

        console.log(response)

        setPageSize(response.data.pageSize)
        setTotalResults(response.data.totalResults)
        setCurrentPage(response.data.currentPage)
        setListPosters([...response.data.list])
        setAmountPages((totalResults % 2 == 0 ? totalResults / pageSize : (totalResults / pageSize) + 1 ))
    }
    
    function calcNumPage() {
        var td = [];
        for (let index = 1; index <= (totalResults % 2 == 0 ? totalResults / pageSize : (totalResults / pageSize) + 1 ); ++index) {
            td.push(index)
        }
        return td;
    }


    return(
            <div>
                <Topbar/>
                <div className="flex flex-col w-full h-screen lg:flex-row items-center justify-center shadow-xl bg-[#FFDEF6]">
        
                        <div className="flex items-start justify-center h-[85%] lg:w-[50%] 
                        w-[90%] shadow-xl bg-white rounded-lg">
                            
                            <div className="flex flex-col w-full items-center justify-center py-10 ">
                                <div className="lg:my-6 justify-center text-center text-4xl mt-[-5%]">
                                    <span className="font-semibold">Categorias</span>
                                </div>
                                
                                <SearchBar/>

                                <div className="flex flex-col w-[80%] justify-center items-center gap-3 lg:mt-[2.5%] mt-[5%]">
                                {listCategorias.map((categoria) => (
                                    <BoxCategory 
                                    id={categoria.id} 
                                    nomeCategoria={categoria.nomeCategoria} 
                                    nomeTag={categoria.nomeTag}
                                    />
                                ))}  

                                {calcNumPage().map((element, index) => 
                                    <div key={index}>
                                        <button onClick={() => fetchMorePosters(element)}>{element}</button>
                                    </div>
                                )}

                                </div>
                            </div>
                        </div>
                </div>

            <Footer/>
            </div>

    )
}