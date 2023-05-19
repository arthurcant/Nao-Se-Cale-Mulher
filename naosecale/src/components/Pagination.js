import { Box } from '../components/Box'
import { Footer } from '../components/Footer'
import { Topbar } from '../components/Topbar'

import { FaHome, FaPhoneAlt, FaFlag, FaInfoCircle, FaExclamationTriangle, FaSearch, FaArrowRight, FaArrowLeft } from 'react-icons/fa';

import React, { useState } from "react";

export function Pagination(){

    let[num,setNum] = useState(1)

    const pages = [
        {page: num},
        {page: num + 1},
        {page: num + 2},
        {page: num + 3}
    ]

    function Next(){
        setNum(++num)
    }

    function Back() {
        num > 1 && setNum(--num)
    }

    return(
        <div className="text-center items-center gap-3 flex flex-row">
            <button onClick={Back}><FaArrowLeft className="text-lg"/></button>
                {
                    pages.map((pg, i) => (
                    <button key={i} >{pg.page}</button>
                    ))
                }
            <button onClick={Next}><FaArrowRight className="text-lg"/></button>
            </div>

    )
}