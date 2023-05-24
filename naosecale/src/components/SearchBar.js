import { FaSearch } from 'react-icons/fa';
import api  from '../services/api'

export function SearchBar(){
    
    return(
        <div className=" hidden bg-white items-center lg:flex shadow-lg border-2 hover:border-pink-500 rounded-full text-black p-2 transition-colors lg:w-64 lg:my-5">
            <FaSearch className="text-lg"/>
    
            <input type="text" className="hover:border-pink-500 focus:outline-none text-black p-2 transition-colors ml-0"/>
        </div>
    )
}