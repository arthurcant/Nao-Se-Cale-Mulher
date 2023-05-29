import { FaSearch } from 'react-icons/fa';
import React from 'react';
import { useEffect, useState } from 'react'

const api = 'https://kitsu.io/api/edge/';

export function SearchBar(){

    const [info, setInfo] = useState({});
    const [text, setText] = useState('');
    console.log(text);

    useEffect(() => {
        console.log(text);
        if (text) {
            fetch(`${api}texto?filter[text]=${text}`)
                .then((response) => response.json())
                .then((response) => {
                    setInfo(response);
                });
        }
    }, [text]);

    const SearchBar = ({ value, onChange}) => {
        function handleChange(event) {
            onChange(event.target.value);
        }
       return <input
       type="search" 
       value={value} 
       onChange={handleChange}>
        </input>

        {info.data && (
            <ul>
                {info.data.map((texto) => (
                    <li key={texto.id}>
                        {texto.attributes.canonicalTitle}
                    </li>
                ))}
            </ul>
        )}
    
    }

    return(
        <div className=" hidden bg-white items-center lg:flex shadow-lg border-2 hover:border-pink-500 rounded-full text-black p-2 transition-colors lg:w-64 lg:my-5">
            <FaSearch className="text-lg"/>
    
            <input 
            value={text}
            onChange={(search) => setText(search)}
             className="hover:border-pink-500 focus:outline-none text-black p-2 transition-colors ml-0"/>
        </div>
    )
}