import { useEffect, useState } from "react";
import { Button,Container, Table } from "react-bootstrap";
import OsobaService from "../../services/OsobaService";
import { ImManWoman } from "react-icons/im";
import { FaRegEdit } from "react-icons/fa";
import { FaRegTrashAlt } from "react-icons/fa";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";



export default function Osobe() {

    const [osobe,setOsobe] = useState();
    const navigate = useNavigate();

    async function dohvatiOsobe(){
        await OsobaService.getOsobe()
        .then((res)=>{
            setOsobe(res.data);
        })
        .catch((e)=>{
            alert(e);
        });
    }

    useEffect(()=>{
        dohvatiOsobe;
    },[]);

    async function ObrisiOsobu(sifra){
        const odgovor = await OsobaService.ObrisiOsobu(sifra);
        if (odgovor.ok){
            alert(odgovor.poruka.data.poruka);
            dohvatiOsobe();
        }
        
    }

    return(
        <Container>
             <Link to={RoutesNames.OSOBE_NOVI} className="btn btn-success gumb">
                <ImManWoman
                size={25}
                /> Dodaj
            </Link>
            <Table striped bordered hover responsive>
               <thead>
                  <tr>
                     <th>Ime</th>
                     <th>Prezime</th>
                     <th>Broj Telefona</th>
                     <th>Email</th>
                     <th>Akcija</th>
                  </tr>
               </thead>
               <tbody>
                    {osobe && osobe.map((osoba,index)=>(
                        <tr key={index}>
                            <td>{osoba.ime}</td>
                            <td>{osoba.prezime}</td>
                            <td>{osoba.brojTelefona}</td>
                            <td>{osoba.email}</td>
                            <td className="sredina">
                                <Button 
                                variant="primary"
                                onClick={()=>{navigate(`/osobe/${osoba.sifra}`)}}>
                                    <FaRegEdit
                                    size={25}
                                    />
                                </Button>
                                
                                    &nbsp;&nbsp;&nbsp;
                                <Button
                                    variant="danger"
                                    onClick={()=>ObrisiOsobu(osoba.sifra)}
                                >
                                    <FaRegTrashAlt 
                                    size={25}
                                    />
                                </Button>

                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>
      
    );


}