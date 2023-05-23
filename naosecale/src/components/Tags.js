
export function Tags(props) {
    return(
        <div>
            {props.categorias.length > 0 && 
            props.categorias.map(c => (
                <span className="inline-flex items-center rounded-md bg-[#6b0023] px-2 py-1 text-xs font-medium text-white">
                    {c.nomeTag}
                </span>
            ))}
        </div>
    )
}
