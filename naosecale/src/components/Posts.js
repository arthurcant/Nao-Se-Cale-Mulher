import React, { useState } from "react";


export function Posts() {
    return(
        <div>
            <div className="border-solid border-2 p-40 lg:m-5 shadow-xl">
                <img classname="object-cover" src=""/>
            </div>

            <div className="mt-0 ml-5  font-weight: 900">
                <span>Autor: 19 DE FEVEREIRO DE 2023</span>
                <div className="font-weight:900 mt-0"><span>Título</span></div>
            </div>

            <div className="m-5">
               <a>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</a>
            </div>
        </div>
    )
}