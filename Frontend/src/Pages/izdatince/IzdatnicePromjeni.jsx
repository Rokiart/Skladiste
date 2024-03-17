import { useEffect, useState } from "react";
import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";

import { RoutesNames } from "../../constants";
import IzdatnicaService from "../../services/IzdatnicaService";


export default function IzdatnicePromjeni(){

    const navigate =useNavigate();
    const routeParams = useParams();
    const [osoba,setIzdatnica] = useState({});

    async function dohvatiIzdatnicu(){
        await IzdatnicaService.getBySifra(routeParams.sifra)
        .then((res)=>{
            setIzdatnica(res.data)
        })
        .catch((e)=>{
            alert(e.poruka);
        });
    }

    useEffect(()=>{
        
        dohvatiIzdatnicu();
    },[]);

    async function promjeniIzdatnicu(Izdatnica){
        const odgovor = await IzdatnicaService.promjeniIzdatnicu(routeParams.sifra,Izdatnica);
        if(odgovor.ok){
          navigate(RoutesNames.IZDATNICE_PREGLED);
        }else{
          console.log(odgovor);
          alert(odgovor.poruka);
        }
    }

    function handleSubmit(e){
        e.preventDefault();
        const podaci = new FormData(e.target);

        const osoba = 
        {
            brojIzdatnice: podaci.get('brojIzdatnice'),
            datum: parseInt(podaci.get('datum')),
            osoba: parseFloat(podaci.get('osoba')),
            skladistar: parseFloat(podaci.get('skladistar')),
            napomena: parseFloat(podaci.get('napomena'))
            
            
          };

          
          promjeniIzdatnicu(Izdatnica);
    }


    return (

        <Container>
           
           <Form onSubmit={handleSubmit}>

                <Form.Group controlId="brojIzdatnice">
                    <Form.Label>Ime</Form.Label>
                    <Form.Control 
                        type="text"
                        defaultValue={Izdatnica.brojIzdatnice}
                        name="brojIzdatnice"
                    />
                </Form.Group>

                <Form.Group controlId="datum">
                    <Form.Label>Prezime</Form.Label>
                    <Form.Control 
                        type="text"
                        defaultValue={Izdatnica.datum}
                        name="datum"
                    />
                </Form.Group>

                <Form.Group controlId="osoba">
                    <Form.Label>Cijena</Form.Label>
                    <Form.Control 
                        type="text"
                        defaultValue={Izdatnica.osoba}
                        name="osoba"
                    />
                </Form.Group>

                <Form.Group controlId="skladistar">
                    <Form.Label>Upisnina</Form.Label>
                    <Form.Control 
                        type="text"
                        defaultValue={izdatnica.skladistar}
                        name="skladistar"
                    />
                </Form.Group>

                <Form.Group controlId="napomena">
                    <Form.Label>Upisnina</Form.Label>
                    <Form.Control 
                        type="text"
                        defaultValue={izdatnica.napomena}
                        name="napomena"
                    />

                </Form.Group>                     

                
                <Row className="akcije">
                    <Col>
                        <Link 
                        className="btn btn-danger"
                        to={RoutesNames.IZDATNICE_PREGLED}>Odustani</Link>
                    </Col>
                    <Col>
                        <Button
                            variant="primary"
                            type="submit"
                        >
                            Promjeni osobu
                        </Button>
                    </Col>
                </Row>
                
           </Form>

        </Container>

    );

}