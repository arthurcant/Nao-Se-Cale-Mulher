import { Box } from '../components/Box'
import { Footer } from '../components/Footer'
import { Topbar } from '../components/Topbar'
import { Pagination } from '../components/Pagination'
import { Posts } from '../components/Posts'

import { FaHome, FaPhoneAlt, FaFlag, FaInfoCircle, FaExclamationTriangle, FaSearch, FaArrowRight, FaArrowLeft } from 'react-icons/fa';

import React, { useState } from "react";

export function Open() {

    return(
        <div>
            <Topbar/>

            <div className="flex flex-col h-screen items-center justify-center shadow-xl bg-[#FFDEF6]">
    
                <div className="flex justify-center bg-white rounded-lg lg:h-[95%] lg:w-[48%] h-[85%] w-[85%]">
                        <div className="text-3xl text-center mt-[7.5%]"><span>Titulo Do Poster</span></div>
                    
                </div>
            </div>
            <Footer/>
        </div>
    )
}