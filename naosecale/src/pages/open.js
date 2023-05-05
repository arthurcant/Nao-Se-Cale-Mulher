import { Box } from '../components/Box'
import { Footer } from '../components/Footer'
import { Topbar } from '../components/Topbar'
import { Pagination } from '../components/Pagination'
import { Posts } from '../components/Posts'

import { FaHome, FaPhoneAlt, FaFlag, FaInfoCircle, FaExclamationTriangle, FaSearch, FaArrowRight, FaArrowLeft } from 'react-icons/fa';

import React, { useState } from "react";

export function Open() {

    return(

        <div className='w-full'>
            <Topbar/>

            <div className="flex flex-row lg:flex-row items-center justify-center shadow-xl bg-[#FFDEF6]">
    
                <div className="lex flex-col justify-center items-center bg-white rounded-lg lg:h-[65%] lg:w-[50%] w-full">
                        <div className="text-3xl text-center mt-[7.5%]"><span>Titulo Do Poster</span></div>
                        <Posts/>
                    
                        <div className="ml-[40%] mb-[5%]"><Pagination/></div>
                </div>
            </div>
            <Footer/>
        </div>
    )
}