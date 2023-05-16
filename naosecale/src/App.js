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
import { ChakraProvider } from '@chakra-ui/react'


export default function App() {

  const [itens, setItens] = useState([])

  useEffect(() => {
    const fetchData = async () => {
      const result = await fetch('https://jsonplaceholder.typicode.com/todos')
        .then(response => response.json())
        .then(data => data)

      setItens(result)
    }
    fetchData()
  }, [])

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

