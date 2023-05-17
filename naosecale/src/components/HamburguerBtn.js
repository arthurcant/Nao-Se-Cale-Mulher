import {
    Menu,
    MenuButton,
    MenuList,
    MenuItem,
    MenuItemOption,
    MenuGroup,
    MenuOptionGroup,
    MenuDivider,
} from '@chakra-ui/react'

import { FaHome, FaPhoneAlt, FaFlag, FaInfoCircle, FaExclamationTriangle, FaSearch } from 'react-icons/fa';

import { Link } from 'react-router-dom'

export function Hamburguer(){
    return(
        <Menu>
            <MenuButton >
                <div className="flex flex-col items-center justify-center text-lg gap-1">
                    <div className="w-8 h-1 bg-white rounded-full" />
                    <div className="w-8 h-1 bg-white rounded-full" />
                    <div className="w-8 h-1 bg-white rounded-full" />
                </div>
            </MenuButton>
            <MenuList>
                <div className="text-pink-600">
                    <Link to="/">
                        <MenuItem>
                            <div className='flex flex-row items-center w-full gap-2'>
                                <FaHome className="text-lg" />
                                Início
                            </div>
                        </MenuItem>
                    </Link>
                    <Link to="/categories" className='flex items-center w-full'>
                        <MenuItem>
                            <div className='flex flex-row items-center w-full gap-2'>
                                <FaFlag className="text-lg" />
                                Categoria
                            </div>
                        </MenuItem>
                    </Link>
                    <Link to="/sobre">
                        <MenuItem>
                            <div className='flex flex-row items-center w-full gap-2'>
                                <FaInfoCircle className="text-lg" />
                                Sobre
                            </div>
                        </MenuItem>
                    </Link>
                    <Link to="/contato">
                        <MenuItem>
                            <div className='flex flex-row items-center w-full gap-2'>
                                <FaPhoneAlt className="text-lg" />
                                Contato
                            </div>
                        </MenuItem>
                    </Link>
                    <div className='flex items-center w-full'>
                        <MenuItem>
                            <div className='flex flex-row items-center w-full gap-2'>
                                <FaExclamationTriangle className="text-lg" />
                                Ligue 180
                            </div>
                        </MenuItem>
                    </div>
                </div>
            </MenuList>
        </Menu>
    )
}