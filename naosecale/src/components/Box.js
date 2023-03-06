export function Box(){
    return(
        <div className="flex flex-col w-20 h-20 justify-center items-center mr-5 hover:cursor-pointer hover:scale-105 transition-all group">
            <div className="bg-red-500 w-full h-[50%] rounded-t-lg group-hover:bg-green-700 transition-colors" />
            <div className="bg-white w-full h-[50%] rounded-b-lg shadow-xl" />
        </div>
    )

}