import { useEffect, useState } from "react";
import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";

import { RoutesNames } from "../../constants";
import IzdatnicaService from "../../services/IzdatnicaService";



export default function IzdatnicePromjeni(){

    const navigate =useNavigate();
    const routeParams = useParams();
    const [izdatnica,setIzdatnica] = useState({});

    async function dohvatiIzdatnicu(){
        await IzdatnicaService.getBySifra(routeParams.sifra)
        .then((response)=>{
            setIzdatnica(response.data)
        })
        .catch((e)=>{
            alert(e.poruka);
        });
    }

    useEffect(()=>{
        
        dohvatiIzdatnicu();
    },[]);

    async function promjeniIzdatnicu(izdatnica){
        const odgovor = await IzdatnicaService.promjeniIzdatnicu(routeParams.sifra,izdatnica);
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

        if(podaci.get('datum')=='' && podaci.get('vrijeme')!=''){
            alert('Ako postavljate vrijeme morate i datum');
            return;
          }
          let datum ='';
          if(podaci.get('datum')!='' && podaci.get('vrijeme')==''){
            datum = podaci.get('datum') + 'T00:00:00.000Z';
          }else{
            datum = podaci.get('datum') + 'T' + podaci.get('vrijeme') + ':00.000Z';
          }
      

        const izdatnica = 
        {
            brojIzdatnice: podaci.get('brojIzdatnice'),
            datum: datum,
            // proizvod: podaci.get('proizvod'),
            osoba: podaci.get('osoba'),
            skladistar: podaci.get('skladistar'),
            napomena: podaci.get('napomena')
            
            
          };

          
          promjeniIzdatnicu(izdatnica);
    }


    return (

        <Container className='mt-4'>
           
           <Form onSubmit={handleSubmit}>

                <Form.Group  className='mb-3' controlId="brojIzdatnice">
                    <Form.Label>Broj Izdatnice</Form.Label>
                    <Form.Control 
                        type="text"
                        defaultValue={izdatnica.brojIzdatnice}
                        name="brojIzdatnice"
                        maxLength={50}
                       
                    />
                </Form.Group>

                <Form.Group className='mb-3' controlId="datum">
                    <Form.Label>Datum</Form.Label>
                    <Form.Control 
                        type="text"
                        defaultValue={izdatnica.datum}
                        name="datum"
                        
                    />
                </Form.Group>

                <Form.Group className='mb-3' controlId='vrijeme'>
                    <Form.Label>Vrijeme</Form.Label>
                    <Form.Control
                         type='time'
                         name='vrijeme'
                         
                    />
                </Form.Group>


                {/* <Form.Group className='mb-3' controlId="proizvod">
                    <Form.Label>Proizvod</Form.Label>
                    <Form.Control 
                        type="text"
                        defaultValue={izdatnica.proizvod}
                        name="proizvod"
                        required
                    />
                </Form.Group> */}

                

                <Form.Group className='mb-3' controlId="osoba">
                    <Form.Label>Osoba</Form.Label>
                    <Form.Control 
                        type="text"
                        defaultValue={izdatnica.osoba}
                        name="osoba"
                        
                    />
                </Form.Group>

                <Form.Group className='mb-3' controlId="skladistar">
                    <Form.Label>Skladistar</Form.Label>
                    <Form.Control 
                        type="text"
                        defaultValue={izdatnica.skladistar}
                        name="skladistar"
                       
                    />
                </Form.Group>

                <Form.Group className='mb-3' controlId="napomena">
                    <Form.Label>Napomena</Form.Label>
                    <Form.Control 
                        type="text"
                        defaultValue={izdatnica.napomena}
                        name="napomena"
                        maxLength={250}
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
                            Promjeni podatke izdatnice
                        </Button>
                    </Col>
                </Row>
                
           </Form>

        </Container>

    );

}