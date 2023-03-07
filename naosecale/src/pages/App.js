import { Box } from '../components/Box'

export default function App() {
  return (
    <div className="geral">
      <div className="text-base flex flex-row items-center justify-between pl-1 pr-5 pt-7 pb-7 shadow-xl text-red-600 ">
        <div className="hidden flex-row md:flex ml-20">

          <div className="italic font-extrabold flex flex-row items-center ml-20 text-2xl">
            <span>Não Se Cale !</span>
          </div>

          <input type="text" className="BTD shadow-2xl border-2 border-black-500 ml-10 rounded-full text-black pr-8"/>

          <div className="underline flex flex-row items-center ml-20 pl-20">
            <span>Home</span>
          </div>

          <div className="underline flex flex-row items-center ml-0 pl-10">
            <span>Categorias</span>
          </div>

          <div className="underline flex flex-row items-center ml-5 pl-6">
            <span>Sobre</span>
          </div>

          <div className="underline flex flex-row items-center ml-5 pl-6">
            <span>Contato</span>
          </div>

          <div className="underline flex flex-row items-center ml-10 pl-6">
            <span>Ligue 180</span>
          </div>
        </div>
      </div>

        <div className="w-full h-full justify-center items-center align-middle bg-[#A1607F] p-8">
          <div className="flex flex-col w-full lg:w-[45%] pt-2 lg:pt20 pl-20 items-center ml-20">
            <a className="italic font-extrabold text-2xl pb-14">Lorem ipsum</a>
            <span>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum</span>
          </div>
        </div>

        <div className="text-base flex flex-row items-center justify-between pl-1 pr-5 pt-7 pb-7 shadow-xl text-black ">

        <div className=" bg-[#B39BA6] border-solid border-2 border-black p-20 pt-10 mt-20">
            <a>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum</a>
          </div>

        <div className="p-10 bg-white">

        </div>

        <div className=" bg-[#B39BA6] border-solid border-2 border-black p-20 pt-10 ml-15 mt-20">
        <a>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum</a>

        </div>

          </div>

    </div>
  
    
  );
}

