import "../styles/Card.css"

export default function Card(props) {
    return (
        <a href={props.repository.htmlUrl}>
            <div className="card">
                <div className="card-header d-flex">
                    <h5 className="card-title no-wrap">{props.repository.name}</h5>
                </div>
                <div className="card-body row ">
                    <div className="col-6 d-flex flex-column">
                        <span >{props.repository.autor}</span>
                        <span className="no-wrap mt-2">{props.repository.description}</span>
                    </div>

                    <div className="col-6 d-flex flex-column text-end">
                        <span className="bi bi-star">{props.repository.stargazers}</span>
                        <span className="bi bi-eye mt-2">{props.repository.watchers}</span>
                    </div>

                </div>
            </div>
        </a>
        
    )
}