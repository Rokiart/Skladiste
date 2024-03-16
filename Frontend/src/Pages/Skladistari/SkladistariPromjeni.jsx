
import { useEffect, useState } from "react";
import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import SkladistarService from "../../services/SkladistarService";
import { RoutesNames } from "../../constants";



export default function SkladistaraPromjeni(){

    const [skladistar, setSkladistar] = useState({});

    const routeParams = useParams();
    const navigate = useNavigate();

    async function dohvatiSkladistara(){
        await SkladistarService
        .getBySifra(routeParams.sifra)
        .then((response) => {
          console.log(response);
          setPolaznik(response.data);
        })
        .catch((err) => alert(err.poruka));
    }

    useEffect(()=>{
        
        dohvatiSkladistara();
    },[]);

    async function promjeniSkladistara(skladistar){
        const odgovor = await SkladistarService.promjeni(routeParams.sifra,skladistar);
        if(odgovor.ok){
          navigate(RoutesNames.SKLADISTARI_PREGLED);
        }else{
          console.log(odgovor);
          alert(odgovor.poruka);
        }
    }

    function handleSubmit(e){
        e.preventDefault();
        

        const podaci = new FormData(e.target);
         promjeniSkladistar({
            ime: podaci.get('ime'),
            prezime: parseInt(podaci.get('prezime')),
            brojTelefona: parseFloat(podaci.get('broj telefona')),
            email: parseFloat(podaci.get('email')),
            
        });

          
         
    }


    return (

        <Container>
           
           <Form onSubmit={handleSubmit}>

                <Form.Group controlId="ime">
                    <Form.Label>Ime</Form.Label>
                    <Form.Control 
                        type="text"
                        defaultValue={osoba.ime}
                        name="ime"
                    />
                </Form.Group>

                <Form.Group controlId="prezime">
                    <Form.Label>Prezime</Form.Label>
                    <Form.Control 
                        type="text"
                        defaultValue={osoba.prezime}
                        name="prezime"
                    />
                </Form.Group>

                <Form.Group controlId="brojTelefona">
                    <Form.Label>Cijena</Form.Label>
                    <Form.Control 
                        type="text"
                        defaultValue={osoba.brojTelefona}
                        name="brojTelefona"
                    />
                </Form.Group>

                <Form.Group controlId="email">
                    <Form.Label>Upisnina</Form.Label>
                    <Form.Control 
                        type="text"
                        defaultValue={osoba.email}
                        name="email"
                    />
                </Form.Group>

                
                <Row className="akcije">
                    <Col>
                        <Link 
                        className="btn btn-danger"
                        to={RoutesNames.SKLADISTARI_PREGLED}>Odustani</Link>
                    </Col>
                    <Col>
                        <Button
                            variant="primary"
                            type="submit"
                        >
                            Promjeni skladistara
                        </Button>
                    </Col>
                </Row>
                
           </Form>

        </Container>

    );

}