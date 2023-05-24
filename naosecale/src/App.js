import { Index } from './pages/index'
import { About } from './pages/about'
import { Contact } from './pages/contact'
import { Categories } from './pages/categories'
import { Login } from './pages/login'
import { Register } from './pages/register'
import { Write } from './pages/write'
import { Open } from './pages/open'
import { Routes, Route } from "react-router-dom";
import { useEffect, useState } from 'react'
import api  from './services/api'
import { ChakraProvider } from '@chakra-ui/react'


export default function App() {
  useEffect(() => {
    async function login() {

      const data = {
          email: "arthurbig12@gmail.com",
          password: "admin213!"
      }
      
      try {
          
          const response = await api.post('/api/Autenticacao/v1/signin', data);
          console.log("Inicial login " + response);
          localStorage.setItem('email', data.email);
          localStorage.setItem('accessToken', response.data.accessToken);
          localStorage.setItem('refreshToken', response.data.refreshToken);
          
      }catch(error){
          
      }
      console.log("Chamando função login");
  }

    login()

  },[])

  return (
    <ChakraProvider>
      <Routes>
        <Route path="/" element={<Index />} />
        <Route path="/sobre" element={<About />} />
        <Route path="/contato" element={<Contact />} />
        <Route path="/categories" element={<Categories />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="/write" element={<Write />} />
        <Route path="/open" element={<Open />} />
      </Routes>
    </ChakraProvider>
  );
}

