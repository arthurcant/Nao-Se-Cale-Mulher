import React, { useState } from "react";


export function Posts(props) {
    
    return(
        <div key={props.id}>
            <div className="border-solid border-2 p-40 lg:m-5 shadow-xl">
                <img className="object-cover"/>
            </div>

            <div className="mt-0 ml-5  font-weight: 900">
                <div className="font-weight:900 mt-0"><span>{props.titulo}</span></div>
                <span>{props.dataDaPublicacao}</span>
            </div>

            <div className="m-5">
                <a>{props.descricao}</a>
            </div>
        </div>
    )
}