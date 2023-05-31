import { Link } from "react-router-dom";

import { Hamburguer } from './HamburguerBtn'
import { SearchBar } from './SearchBar'
import { FaHome, FaPhoneAlt, FaFlag, FaInfoCircle, FaExclamationTriangle, FaSearch } from 'react-icons/fa';

import React, { useState } from "react";

import Popover from '@mui/material/Popover';
import Alert from '@mui/material/Alert';
import Button from '@mui/material/Button';
import { Typography } from "@mui/material";


export function Topbar() {
    function copyToClipboard(){
        navigator.clipboard.writeText('180')
        alert('O número 180 foi copiado!')
    }

    return (
        <div className="flex flex-row w-full  items-center justify-between shadow-xl text-white bg-[#6b0023] px-10 py-7 lg:py-0">
            <div className="italic font-extrabold items-center text-xl lg:text-2xl">
                <Link to="/"><span className="hidden lg:flex">Não Se Cale Mulher</span></Link>
                <Link to="/"><span className="flex lg:hidden">Não Se Cale Mulher</span></Link>
            </div>

            <SearchBar />

            <div className="hidden lg:flex gap-4">
                <Link to="/">
                    <div className="underline flex flex-row items-center gap-1">
                        <FaHome className="text-lg" />
                        <span>Home</span>
                    </div>
                </Link>

                <Link to="/categories">
                    <div className="underline flex flex-row items-center gap-1">
                        <FaFlag className="text-lg" />
                        <span>Categorias</span>
                    </div>
                </Link>

                <Link to="/sobre">
                    <div className="underline flex flex-row items-center gap-1">
                        <FaInfoCircle className="text-lg" />
                        <span>Sobre</span>
                    </div>
                </Link>

                <Link to="/contato">
                    <div className="underline flex flex-row items-center gap-1 ">
                        <FaPhoneAlt className="text-lg" />
                        <span>Contato</span>
                    </div>
                </Link>

                <div onClick={() => copyToClipboard()} className="underline flex flex-row items-center gap-1 cursor-pointer">
                    <FaExclamationTriangle className="text-lg" />
                    <span>Ligue 180</span>
                </div>
            </div>

            <div className="flex lg:hidden">
                <Hamburguer />
            </div>
        </div>
    )
}