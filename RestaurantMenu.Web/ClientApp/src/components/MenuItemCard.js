import React from 'react';
import {
  Box,
  Flex,
  Image,
  Text,
  Tag,
  Divider 
} from '@chakra-ui/react'

export const MenuItemCard = ({ item }) => {
  return (
    <>
    <Flex justifyContent={'space-between'} flexDirection='row' margin={'20px'}>
      <Image height={'80px'} width='80px' src={item?.imageUrl} />
      <Flex flexDirection='column'>
        <Text  fontSize={'30px'}>{item?.name}</Text>
        <Text fontSize={'15px'}>{item?.description}</Text>
        <Flex flexDirection='row'>
          {item?.ingridients.map(ingridient => {
            return ( <Tag variant='solid' colorScheme='teal' margin={"5px"}>{ingridient}</Tag> )
          
          })}
        </Flex>
      </Flex>
      <Box>{item?.price}€</Box>
    </Flex>
    <Divider variant={"dashed"} colorScheme='white' />
    </>
  )
}

