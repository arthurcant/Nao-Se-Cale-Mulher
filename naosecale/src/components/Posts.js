import React, { useState } from "react";
import { Tags } from "./Tags";

export function Posts(props) {
    
    return(
        <div key={props.id} className="flex flex-col gap-5">
            <div className="border-solid border-2 p-40 shadow-md">
                <img className="object-cover" src="../src/img/Mulher.png"/>
            </div>

            <div className="font-weight: 900">
                <div className="font-weight:900 text-lg  font-bold"><span>"{props.titulo}"</span></div>
                <span className="font-light">{props.dataDaPublicacao}</span>
            </div>

            <div className="">
                <a className="font-light">{props.descricao}</a>
            </div>
            <Tags categorias={props.categorias} />
        </div>
    )
}